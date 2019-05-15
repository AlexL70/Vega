import { Component, OnInit, isDevMode } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastyService } from 'ng2-toasty';
import { Observable } from 'rxjs';
import 'rxjs/add/observable/forkJoin';

import { Make } from '../../models/Make';
import { Model } from '../../models/Model';
import { Feature } from '../../models/Feature';
import { Vehicle } from '../../models/Vehicle';
import { SaveVehicle } from '../../models/SaveVehicle';
import { VehicleService } from '../../services/vehicle.service';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  makes: Make[];
  models: Model[] = [];
  features: Feature[] = [];
  vehicle: SaveVehicle = {
    id: 0,
    makeId: 0,
    modelId: 0,
    isRegistered: false,
    featureIds: [],
    contact: { name: "", phone: "", email: "" }
  };
  isDevMode: boolean = isDevMode();

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private vehicleService: VehicleService,
    private toastyService: ToastyService) {
      route.params.subscribe(p => {
        this.vehicle.id = +p['id'] || 0;
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
        if(this.vehicle.id) {
          this.setVehicle(data[2])
          this.populateModels();
        }
      }, err => {
        // console.log(err);
        if(err.status == 404)
          this.router.navigate(['/']);
      });
  }

  private setVehicle(v: Vehicle) {
    this.vehicle.id = v.id;
    this.vehicle.makeId = v.make.id;
    this.vehicle.modelId = v.model.id;
    this.vehicle.featureIds = [];
    v.features.forEach((val, index, arr) => this.vehicle.featureIds.push(val.id));
    this.vehicle.isRegistered = v.isRegistered;
    this.vehicle.contact.name = v.contact.name;
    this.vehicle.contact.email = v.contact.email;
    this.vehicle.contact.phone = v.contact.phone;
  }

  onMakeChange(): void {
    this.populateModels();
    delete this.vehicle.modelId;
  }

  private populateModels(): void {
    var selectedMake = this.makes.find(m => m.id == this.vehicle.makeId);
    this.models = selectedMake ? selectedMake.models.slice() : [];
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
    let title = "Saved";
    let message = "Vehicle is successfully updated.";
    let result$ = this.vehicle.id
      ? this.vehicleService.update(this.vehicle)
      : this.vehicleService.create(this.vehicle);
    if (!this.vehicle.id) {
      title = "Created";
      message = "Vehicle is successfully created.";
    }
    result$.subscribe(
        v => {
          this.toastyService.success({
            title: title,
            msg: message,
            showClose: true,
            timeout: 5000,
            theme: 'bootstrap'
          });
          this.router.navigate(['/vehicles/', v.id]);
      });
  }

  cancel(): void {
    if (this.vehicle.id) {
      this.router.navigate(['/vehicles/', this.vehicle.id])
    } else {
      this.router.navigate(['/vehicles']);
    }
  }
}
