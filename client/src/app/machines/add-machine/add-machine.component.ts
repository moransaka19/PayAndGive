import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';

@Component({
  templateUrl: './add-machine.component.html',
  styleUrls: ['./add-machine.component.scss']
})
export class AddMachineComponent implements OnInit {

  form: FormGroup;

  constructor(private http: HttpClient,
              private router: Router) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      state: new FormControl(),
      value: new FormControl()
    });
  }

  onAddMachine() {
    this.http.post(`${environment.apiUrl}/machines`, this.form.value)
      .subscribe(() => this.router.navigateByUrl('/machines'));
  }
}
