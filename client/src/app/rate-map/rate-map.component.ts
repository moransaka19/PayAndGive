import {Component, OnInit} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {environment} from '../../environments/environment';

@Component({
  selector: 'app-rate-map',
  templateUrl: './rate-map.component.html',
  styleUrls: ['./rate-map.component.scss']
})
export class RateMapComponent implements OnInit {
  eats$: Observable<any[]>;
  containers$: Observable<any[]>;
  selectedEat;

  myType = 'GeoChart';
  columnNames = ['City', 'Price'];
  data = [['UA', 1]];
  width = 800;
  height = 600;
  options: any;

  constructor(private http: HttpClient) {
  }

  ngOnInit(): void {
    this.eats$ = this.http.get<any[]>(environment.apiUrl + '/eats');
  }

  onSelectEat(id) {
    this.http.get<any[]>(environment.apiUrl + '/containers/sold/' + id)
      .subscribe(c => {
        this.data = c.map(x => {
          console.log([x.country, x.price]);
          return [x.country, x.price];
        });
        console.log(c);
      }, e => console.log(e));
  }
}
