import { FeatureService, Feature } from './../services/feature.service';
import { MakeService, Make, Model } from './../services/make.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  makes: Make[];
  models: Model[] = [];
  features: Feature[] = [];
  vehicle: any = {};

  constructor(private makeService: MakeService,
    private feagureService: FeatureService) { }

  ngOnInit() {
    this.makeService.getMakes().subscribe(
      makes => this.makes = makes);
    this.feagureService.getFeatures().subscribe(
      features => this.features = features);
  }

  onMakeChange() {
    var selectedMake = this.makes.find(m => m.id == this.vehicle.make);
    this.models = selectedMake ? selectedMake.models.slice() : [];
  }

}
