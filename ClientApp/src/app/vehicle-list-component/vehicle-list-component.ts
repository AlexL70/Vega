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
  allVehicles: Vehicle[];
  makes: KeyValuePair[];
  filter: any = {};

  constructor(private vehicleService: VehicleService) { }

  ngOnInit() {
    this.vehicleService.getVehicles()
      .subscribe(vehicles => this.vehicles = this.allVehicles = vehicles);
    this.vehicleService.getMakes()
      .subscribe(makes => this.makes = makes);
  }

  onFilterChange() {
    var vehicles = this.allVehicles;

    if(this.filter.makeId) {
      // console.log(this.filter.makeId);
      vehicles = vehicles.filter(val =>
        val.make.id === +this.filter.makeId );
    }

    //  More filters could be added here if necessary

    this.vehicles = vehicles;
  }

  resetFilter() {
    this.filter = {};
    this.onFilterChange();
  }
}
