import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';

@Component({
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  form: FormGroup;

  constructor(private http: HttpClient,
              private router: Router) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      login: new FormControl(''),
      password: new FormControl('')
    });
  }

  onLogin() {
    this.http.post(`${environment.apiUrl}/auth/login`, this.form.value)
      .subscribe(({ token }: { token: string }) => {
        localStorage.setItem('token', token);
        this.router.navigateByUrl('machines');
      });
  }
}
