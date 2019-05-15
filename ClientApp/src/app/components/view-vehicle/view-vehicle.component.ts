import { VehicleService } from './../../services/vehicle.service';
import { ToastyService } from 'ng2-toasty';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit, isDevMode } from '@angular/core';
import { Vehicle } from './../../models/Vehicle';

@Component({
  templateUrl: './view-vehicle.component.html',
  styleUrls: ['./view-vehicle.component.css']
})
export class ViewVehicleComponent implements OnInit {
  vehicle: Vehicle;
  vehicleId: number;
  isDevMode: boolean = isDevMode();
  activeTab: string = "basics"

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private toasty: ToastyService,
    private vehicleService: VehicleService
  ) {
    route.params.subscribe(p => {
      this.vehicleId = +p['id'];
      if (isNaN(this.vehicleId) || this.vehicleId <= 0) {
        this.router.navigate(['/vehicles']);
        return;
      }
    });
  }

  ngOnInit() {
    this.vehicleService.getVehicle(this.vehicleId)
      .subscribe(
        v => this.vehicle = v,
        err => {
          if (err.status == 404) {
            this.router.navigate(['/vehicles']);
            return;
          }
        }
      );
  }

  edit() {
    this.router.navigate(['/vehicles/edit/', this.vehicleId]);
  }

  delete() {
    if(confirm("Are you sure?")) {
      this.vehicleService.delete(this.vehicle.id)
        .subscribe(x => {
          this.toasty.success({
            title: "Saved",
            msg: "Vehicle is successfully deleted.",
            showClose: true,
            timeout: 5000,
            theme: 'bootstrap'
          });
      });
    }
  }

  toList() {
    this.router.navigate(['/vehicles']);
  }

  toBasics() {
    this.activeTab = "basics";
  }

  toPicture() {
    this.activeTab = "picture";
  }
}
