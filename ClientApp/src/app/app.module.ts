import { AdminAuthGuard } from './services/admin-auth-guard.service';
import { AuthGuard } from './services/auth-guard.service';
import { Auth } from './services/auth.service';
import { AppErrorHandler } from './app.error.handler';
import { ErrorHandler } from '@angular/core';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { ToastyModule } from 'ng2-toasty';
import * as Sentry from '@sentry/browser';

import { VehicleService } from './services/vehicle.service';
import { PhotoService } from './services/photo.service';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HomeComponent } from './components/home/home.component';
import { CounterComponent } from './components/counter/counter.component';
import { FetchDataComponent } from './components/fetch-data/fetch-data.component';
import { VehicleFormComponent } from './components/vehicle-form/vehicle-form.component';
import { VehicleListComponent } from './components/vehicle-list/vehicle-list.component';
import { PaginationComponent } from './components/shared/pagination/pagination.component';
import { ViewVehicleComponent } from './components/view-vehicle/view-vehicle.component';
import { AdminComponent} from './components/admin/admin.component';

Sentry.init({
  dsn: "https://f744306dfa3249e8a86ff4b4b14ef880@sentry.io/1455076"
});
@NgModule({
  declarations: [
    AppComponent,
    AdminComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    VehicleFormComponent,
    VehicleListComponent,
    PaginationComponent,
    ViewVehicleComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ToastyModule.forRoot(),
    RouterModule.forRoot([
      { path: '', redirectTo: 'vehicles', pathMatch: 'full' },
      { path: 'vehicles/new', component: VehicleFormComponent, canActivate: [AuthGuard] },
      { path: 'vehicles/:id', component: ViewVehicleComponent },
      { path: 'vehicles/edit/:id', component: VehicleFormComponent, canActivate: [AuthGuard] },
      { path: 'vehicles', component: VehicleListComponent},
      { path: 'admin', component: AdminComponent, canActivate: [AuthGuard, AdminAuthGuard]},
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
    ])
  ],
  providers: [
    { provide: ErrorHandler, useClass: AppErrorHandler},
    VehicleService,
    PhotoService,
    Auth,
    AuthGuard,
    AdminAuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
