import { Component, OnInit } from '@angular/core';
import {Observable} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../environments/environment';

@Component({
  selector: 'app-restaurants',
  templateUrl: './restaurants.component.html',
  styleUrls: ['./restaurants.component.scss']
})
export class RestaurantsComponent implements OnInit {

  restaurants$: Observable<any>;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.restaurants$ = this.http.get(`${environment.apiUrl}/restaurants`);
  }

}
