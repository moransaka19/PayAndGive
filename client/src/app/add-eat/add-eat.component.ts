import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';

@Component({
  templateUrl: './add-eat.component.html',
  styleUrls: ['./add-eat.component.scss']
})
export class AddEatComponent implements OnInit {

  form: FormGroup;

  constructor(private http: HttpClient,
              private router: Router) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      name: new FormControl(),
      price: new FormControl(),
      timeExpiredMin: new FormControl()
    });
  }

  onAddEat() {
    this.http.post(`${environment.apiUrl}/eats`, this.form.value)
      .subscribe(() => this.router.navigateByUrl('/machines'));
  }
}
