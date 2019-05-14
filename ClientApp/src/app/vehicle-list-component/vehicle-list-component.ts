import { ColumnHeader } from './../models/ColumnHeader';
import { VehicleQuery } from './../models/VehicleQuery';
import { Component, OnInit } from '@angular/core';

import { VehicleService } from './../services/vehicle.service';
import { Vehicle } from './../models/Vehicle';
import { KeyValuePair } from './../models/KeyValuePair';

@Component({
  selector: 'app-vehicle-list-component',
  templateUrl: './vehicle-list-component.html',
  styleUrls: ['./vehicle-list-component.css']
})
export class VehicleListComponent implements OnInit {
  vehicles: Vehicle[];
  makes: KeyValuePair[];
  query: VehicleQuery = { makeId: null, sortBy: null, isAscending: null };
  columns: ColumnHeader[] = [
    { title: 'Id', sortKey: 'id', isSortable: true},
    { title: 'Make', sortKey: 'make', isSortable: true},
    { title: 'Model', sortKey: 'model', isSortable: true},
    { title: 'Contact Name', sortKey: 'contactName', isSortable: true},
    { title: '', sortKey: null, isSortable: false},
  ];

  constructor(private vehicleService: VehicleService) { }

  ngOnInit() {
    this.vehicleService.getMakes()
      .subscribe(makes => this.makes = makes);
    this.populateVehicles();
  }

  onFilterChange() {
    this.populateVehicles();
  }

  sortBy(columnName: string) {
    if(this.query.sortBy === columnName) {
      this.query.isAscending = !this.query.isAscending;
    } else {
      this.query.isAscending = true;
      this.query.sortBy = columnName;
    }
    this.populateVehicles();
  }

  private populateVehicles() {
    this.vehicleService.getVehicles(this.query)
      .subscribe(vehicles => this.vehicles = vehicles);
  }

  resetFilter() {
    this.query.makeId = null;
    this.onFilterChange();
  }
}
