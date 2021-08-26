import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import {LoginComponent} from './login/login.component';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {HttpClientModule, HTTP_INTERCEPTORS, HttpClient} from '@angular/common/http';
import {HeaderComponent} from './header/header.component';
import {RegisterComponent} from './register/register.component';
import {AuthInterceptor} from './helpers/auth.interceptor';
import {MachinesComponent} from './machines/machines.component';
import {MachineDetailsComponent} from './machines/machine-details/machine-details.component';
import {AddMachineComponent} from './machines/add-machine/add-machine.component';
import {AddContainerComponent} from './add-container/add-container.component';
import {AddEatComponent} from './add-eat/add-eat.component';
import {TranslateHttpLoader} from '@ngx-translate/http-loader';
import {TranslateLoader, TranslateModule} from '@ngx-translate/core';
import {ReportComponent} from './report/report.component';
import {AdminComponent} from './admin/admin.component';
import {RateMapComponent} from './rate-map/rate-map.component';
import {GoogleChartsModule} from 'angular-google-charts';
import { GoogleMapComponent } from './google-map/google-map.component';
import {GoogleMapsModule} from "@angular/google-maps";
import { RestaurantsComponent } from './restaurants/restaurants.component';
import { AddRestaurantComponent } from './restaurants/add-restaurant/add-restaurant.component';
import { RestaurantDetailsComponent } from './restaurants/restaurant-details/restaurant-details.component';

export function createTranslateLoader(http: HttpClient) {
  return new TranslateHttpLoader(http, './assets/i18n/', '.json');
}

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HeaderComponent,
    RegisterComponent,
    MachinesComponent,
    MachineDetailsComponent,
    AddMachineComponent,
    AddContainerComponent,
    AddEatComponent,
    ReportComponent,
    AdminComponent,
    RateMapComponent,
    GoogleMapComponent,
    RestaurantsComponent,
    AddRestaurantComponent,
    RestaurantDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    ReactiveFormsModule,
    HttpClientModule,
    GoogleChartsModule.forRoot({mapsApiKey: 'AIzaSyBL4bREvpGuhrkcLeaEgBM5I_cdlKMJRlM'}),
    GoogleMapsModule,
    TranslateModule.forRoot({
      defaultLanguage: 'en',
      loader: {
        provide: TranslateLoader,
        useFactory: (createTranslateLoader),
        deps: [HttpClient]
      }
    }),
    FormsModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule {
}
