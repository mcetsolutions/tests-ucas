function New-IisWebSite([string]$SiteName, [string]$Path, [string]$HostHeader, [string]$AppPoolName)
{
    if (!(Test-Path "IIS:\Sites\$SiteName")) { 

        Write-Output "Creating Web Site $SiteName"
		New-Website -Name $SiteName -ApplicationPool $AppPoolName -HostHeader $HostHeader.ToLower() -PhysicalPath $Path -Port 80
    }
    else {
        Write-Output "Website $SiteName already exists"
    }
}

function Set-ApplicationPool([string]$AppPoolName, [string]$AppPoolFrameworkVersion, [string]$AppPoolEnable32bit)
{
    if (!(Test-Path IIS:\AppPools\$AppPoolName)) { 

        Write-Output "Creating App Pool $AppPoolName"
        New-WebAppPool -Name $AppPoolName -Force
    }
    else {
        Write-Output "App Pool $AppPoolName already exists"
    }

    Write-Output "Configuring App Pool $AppPoolName"
    Set-ItemProperty IIS:\AppPools\$AppPoolName -Name managedRuntimeVersion -Value $AppPoolFrameworkVersion
	Set-ItemProperty IIS:\AppPools\$AppPoolName -Name enable32BitAppOnWin64 -Value $AppPoolEnable32bit
}

function Add-HostsFileEntry([string]$HostHeader) {

    if ((Get-Content "$($env:windir)\system32\Drivers\etc\hosts" ) -notcontains "127.0.0.1 $HostHeader")  {

        Write-Output "Adding hosts file entry for $HostHeader"
        Add-Content -Encoding UTF8  "$($env:windir)\system32\Drivers\etc\hosts" "127.0.0.1 $HostHeader"
    }
    else {
        Write-Output "Hosts file entry for $HostHeader already exists"
    }
}

function Initialize-IisWebSite {
	[CmdletBinding()]
	Param(
		[Parameter(Mandatory=$false)][string] $WebSiteName = "Mcet.Ucas.Event.Service.Query.Api",
		[Parameter(Mandatory=$false)][string] $HostHeader = "event-queryapi.ucas.local",
		[Parameter(Mandatory=$false)][string] $PhysicalPath = "$PSScriptRoot\$WebSiteName",
		[Parameter(Mandatory=$false)][string] $AppPoolName = $WebSiteName + "AppPool",
		[Parameter(Mandatory=$false)][string] $AppPoolFrameworkVersion = "v4.0",
		[Parameter(Mandatory=$false)][string] $AppPoolEnable32bit = "false"
	)

	Import-Module WebAdministration

	Set-ApplicationPool -AppPoolName $AppPoolName -AppPoolFrameworkVersion $AppPoolFrameworkVersion -AppPoolEnable32bit $AppPoolEnable32bit

	New-IisWebSite -SiteName "$WebSiteName" -Path $PhysicalPath -HostHeader $HostHeader -AppPoolName $AppPoolName

    Add-HostsFileEntry -HostHeader $HostHeader
}

Initialize-IisWebSite