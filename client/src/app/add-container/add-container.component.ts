import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { environment } from 'src/environments/environment';

@Component({
  templateUrl: './add-container.component.html',
  styleUrls: ['./add-container.component.scss']
})
export class AddContainerComponent implements OnInit {

  form: FormGroup;

  constructor(private http: HttpClient,
              private router: Router,
              private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      fixedLoadingTime: new FormControl(),
      isEmpty: new FormControl(false),
      machineId: new FormControl(this.route.snapshot.params.id),
      eatId: new FormControl(1)
    });
  }

  onAddContainer() {
    this.http.post(`${environment.apiUrl}/containers`, this.form.value)
      .subscribe(() => this.router.navigateByUrl(`/machines/${this.route.snapshot.params.id}`));
  }
}
