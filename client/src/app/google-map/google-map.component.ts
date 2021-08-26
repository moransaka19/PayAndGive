import { Component, OnInit } from '@angular/core';
import { countries } from 'src/assets/countries';

@Component({
  selector: 'app-google-map',
  templateUrl: './google-map.component.html',
  styleUrls: ['./google-map.component.scss']
})
export class GoogleMapComponent implements OnInit {
  coordinates: any;
  countries: string[];

  constructor() {
    this.countries = JSON.parse(countries).map(x => x.name);
  }

  ngOnInit(): void {
  }

  click(event: google.maps.MapMouseEvent | google.maps.IconMouseEvent) {
    this.coordinates = event.latLng.toString();
  }
}
