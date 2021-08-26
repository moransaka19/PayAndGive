import { Component, OnInit } from '@angular/core';
import { countries } from 'src/assets/countries';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../../environments/environment";
import {Router} from "@angular/router";

@Component({
  selector: 'app-add-restaurant',
  templateUrl: './add-restaurant.component.html',
  styleUrls: ['./add-restaurant.component.scss']
})
export class AddRestaurantComponent implements OnInit {

  coordinates: any;
  lat: number;
  lang: number;
  countries: string[];
  name: string;
  country: string;

  constructor(private http: HttpClient, private router: Router) {
    this.countries = JSON.parse(countries).map(x => x.name);
  }

  ngOnInit(): void {
  }

  click(event: google.maps.MapMouseEvent | google.maps.IconMouseEvent) {
    this.coordinates = event.latLng.toString();
    this.lat = event.latLng.lat();
    this.lang = event.latLng.lng();
  }

  onAddRestaurant(viewName: string, viewCountry: string) {
    const restaurant: any = {
      name : this.name,
      country : viewCountry,
      lat : this.lat,
      lang : this.lang
    };

    this.http.post(`${environment.apiUrl}/restaurants`, restaurant)
      .subscribe(() => this.router.navigateByUrl('/restaurants'));
  }
}
