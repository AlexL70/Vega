export interface VehicleQuery {
  makeId: number;

  sortBy: string;
  isAscending: boolean;
  pageSize: number;
  page: number;
}
