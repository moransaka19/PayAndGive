import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import {Observable} from 'rxjs';

@Component({
  templateUrl: './add-machine.component.html',
  styleUrls: ['./add-machine.component.scss']
})
export class AddMachineComponent implements OnInit {
  restaurants$: Observable<any>;
  form: FormGroup;

  constructor(private http: HttpClient,
              private router: Router) { }

  ngOnInit(): void {
    this.restaurants$ = this.http.get<any>(`${environment.apiUrl}/restaurants`);

    this.form = new FormGroup({
      value: new FormControl(),
      restaurantId: new FormControl()
    });
  }

  onAddMachine() {

    this.http.post(`${environment.apiUrl}/machines`, this.form.value)
      .subscribe(() => this.router.navigateByUrl('/restaurants'));
  }
}
