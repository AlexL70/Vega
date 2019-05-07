import { VehicleService } from '../services/vehicle.service';
import { Component, OnInit } from '@angular/core';
import { ToastyService } from 'ng2-toasty';

import { Make } from '../models/Make';
import { Model } from '../models/Model';
import { Feature } from '../models/Feature';
import { SaveVehicle } from '../models/SaveVehicle';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  makes: Make[];
  models: Model[] = [];
  features: Feature[] = [];
  vehicle: SaveVehicle = new SaveVehicle();

  constructor(private vehicleService: VehicleService,
    private toastyService: ToastyService) { }

  ngOnInit(): void {
    this.vehicleService.getMakes().subscribe(
      makes => this.makes = makes);
    this.vehicleService.getFeatures().subscribe(
      features => this.features = features);
  }

  onMakeChange(): void {
    var selectedMake = this.makes.find(m => m.id == this.vehicle.makeId);
    this.models = selectedMake ? selectedMake.models.slice() : [];
    delete this.vehicle.modelId;
  }

  onFeatureToggle(featureId: number, event: Event): void {
    if((<HTMLInputElement>event.target).checked) {
      this.vehicle.featureIds.push(featureId);
    } else {
      var index = this.vehicle.featureIds.indexOf(featureId);
      if(index > -1)
        this.vehicle.featureIds.splice(index, 1);
    }
  }

  submit(): void {
    this.vehicleService.create(this.vehicle)
      .subscribe(
        x => {
          //console.log(x),
          this.toastyService.success({
            title: "Saved",
            msg: "Vehicle is successfully saved.",
            showClose: true,
            timeout: 5000,
            theme: 'bootstrap'
          }
        );
      });
  }
}
