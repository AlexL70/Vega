import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastyService } from 'ng2-toasty';

import { Make } from '../models/Make';
import { Model } from '../models/Model';
import { Feature } from '../models/Feature';
import { SaveVehicle } from '../models/SaveVehicle';
import { VehicleService } from '../services/vehicle.service';
import { Observable } from 'rxjs';
import 'rxjs/add/observable/forkJoin';

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

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private vehicleService: VehicleService,
    private toastyService: ToastyService) {
      route.params.subscribe(p => {
        this.vehicle.id = +p['id'];
      });
    }

  ngOnInit(): void {
    var sources: Observable<any>[] = [
      this.vehicleService.getMakes(),
      this.vehicleService.getFeatures()
    ];

    if(this.vehicle.id)
      sources.push(this.vehicleService.getVehicle(this.vehicle.id));

    Observable.forkJoin(sources).subscribe(data => {
        this.makes = data[0];
        this.features = data[1];
        if(this.vehicle.id)
          this.vehicle = data[2];
      }, err => {
        // console.log(err);
        if(err.status == 404)
          this.router.navigate(['/']);
      });
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
