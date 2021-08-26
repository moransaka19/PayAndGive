import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import {countries} from '../../assets/countries';

@Component({
  templateUrl: './add-container.component.html',
  styleUrls: ['./add-container.component.scss']
})
export class AddContainerComponent implements OnInit {

  eats$: Observable<any>;

  form: FormGroup;
  countries: string[];

  constructor(private http: HttpClient,
              private router: Router,
              private route: ActivatedRoute) {
    this.countries = JSON.parse(countries).map(x => x.name);
  }

  ngOnInit(): void {
    this.eats$ = this.http.get(`${environment.apiUrl}/eats`);

    this.form = new FormGroup({
      createdTime: new FormControl(),
      machineId: new FormControl(this.route.snapshot.params.id),
      eatId: new FormControl(),
      countryName: new FormControl()
    });
  }

  onAddContainer() {
    this.http.post(`${environment.apiUrl}/containers`, this.form.value)
      .subscribe(() => this.router.navigateByUrl(`/machines/${this.route.snapshot.params.id}`));
  }
}
