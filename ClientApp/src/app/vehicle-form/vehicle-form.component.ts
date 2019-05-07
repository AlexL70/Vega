import { VehicleService } from '../services/vehicle.service';
import { Component, OnInit } from '@angular/core';

import { Make } from '../Models/Make';
import { Model } from '../Models/Model';
import { Feature } from '../Models/Feature';
import { SaveVehicle } from '../Models/SaveVehicle';

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

  constructor(private vehicleService: VehicleService) { }

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
}
