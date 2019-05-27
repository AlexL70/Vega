import { PhotoService } from './../../services/photo.service';
import { VehicleService } from './../../services/vehicle.service';
import { ToastyService } from 'ng2-toasty';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit, isDevMode, ElementRef, ViewChild } from '@angular/core';
import { Vehicle } from './../../models/Vehicle';
import { Subscription } from 'rxjs';

@Component({
  templateUrl: './view-vehicle.component.html',
  styleUrls: ['./view-vehicle.component.css']
})
export class ViewVehicleComponent implements OnInit {
  vehicle: Vehicle;
  photos: any[] = [];
  progress: number = 0;
  vehicleId: number;
  uploadSubscription: Subscription;
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

    this.photoService.getPhotos(this.vehicleId)
      .subscribe(p => this.photos = <any[]>p);
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
    let file = nativeELement.files[0];
    nativeELement.value = '';
    this.uploadSubscription = this.photoService.upload(this.vehicleId, file,
      event => {
        // Compute and show the % done:
        this.progress = Math.round(100 * event.loaded / event.total);
        if(isDevMode)
          console.log(`File "${file.name}" is ${this.progress}% uploaded.`);
      },
      event => this.photos.push(event.body));
  }

  fileIsBeingUploaded() : boolean {
    return (this.progress > 0) && (this.progress < 100);
  }

  cancelUpload() : void {
    if (isDevMode)
      console.log("Cancelling upload.");
    this.uploadSubscription.unsubscribe();
    this.progress = 0;
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
