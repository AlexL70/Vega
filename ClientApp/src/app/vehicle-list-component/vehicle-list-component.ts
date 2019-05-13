import { VehicleFilter } from './../models/vehicleFilter';
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
  filter: VehicleFilter = { makeId: null };

  constructor(private vehicleService: VehicleService) { }

  ngOnInit() {
    this.vehicleService.getMakes()
      .subscribe(makes => this.makes = makes);
    this.populateVehicles();
  }

  onFilterChange() {
    this.populateVehicles();
  }

  private populateVehicles() {
    this.vehicleService.getVehicles(this.filter)
      .subscribe(vehicles => this.vehicles = vehicles);
  }

  resetFilter() {
    this.filter = { makeId: null };
    this.onFilterChange();
  }
}
