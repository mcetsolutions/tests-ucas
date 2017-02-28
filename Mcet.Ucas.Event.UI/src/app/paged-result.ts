  export class PagedResult<T> {
    pageNumber: number;
    pageSize: number;
    totalResults: number;
    totalPages: number;
    items: T[]
}