import { Component, OnInit } from '@angular/core';
import {Observable} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../../environments/environment';
import {ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-restaurant-details',
  templateUrl: './restaurant-details.component.html',
  styleUrls: ['./restaurant-details.component.scss']
})
export class RestaurantDetailsComponent implements OnInit {
  machines$: Observable<any>;

  constructor(private http: HttpClient,
              private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.machines$ = this.http.get(`${environment.apiUrl}/machines/restaurant/${this.activatedRoute.snapshot.params.id}`);
  }
}
