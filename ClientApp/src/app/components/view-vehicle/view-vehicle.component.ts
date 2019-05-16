import { PhotoService } from './../../services/photo.service';
import { VehicleService } from './../../services/vehicle.service';
import { ToastyService } from 'ng2-toasty';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit, isDevMode, ElementRef, ViewChild } from '@angular/core';
import { Vehicle } from './../../models/Vehicle';

@Component({
  templateUrl: './view-vehicle.component.html',
  styleUrls: ['./view-vehicle.component.css']
})
export class ViewVehicleComponent implements OnInit {
  vehicle: Vehicle;
  vehicleId: number;
  @ViewChild('fileInput') fileInput: ElementRef;

  isDevMode: boolean = isDevMode();
  activeTab: string = "basics"

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private toasty: ToastyService,
    private vehicleService: VehicleService,
    private photoService: PhotoService
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

  uploadPhoto() {
    let nativeELement: HTMLInputElement = this.fileInput.nativeElement;
    this.photoService.upload(this.vehicleId, nativeELement.files[0])
      .subscribe(x => console.log(x));
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
