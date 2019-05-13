import { KeyValuePair } from './../models/KeyValuePair';
import { Component, OnInit } from '@angular/core';

import { VehicleService } from './../services/vehicle.service';
import { Vehicle } from './../models/Vehicle';

@Component({
  selector: 'app-vehicle-list-component',
  templateUrl: './vehicle-list-component.html',
  styleUrls: ['./vehicle-list-component.css']
})
export class VehicleListComponent implements OnInit {
  vehicles: Vehicle[];
  makes: KeyValuePair[];
  filter: any = {};

  constructor(private vehicleService: VehicleService) { }

  ngOnInit() {
    this.vehicleService.getVehicles()
      .subscribe(vehicles => this.vehicles = vehicles);
    this.vehicleService.getMakes()
      .subscribe(makes => this.makes = makes);
  }

  onFilterChange() {
    if(this.filter.makeId) {
      console.log(this.filter.makeId);
    }
  }
}
