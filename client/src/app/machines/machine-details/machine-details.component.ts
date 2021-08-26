import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import {tap} from 'rxjs/operators';

@Component({
  templateUrl: './machine-details.component.html',
  styleUrls: ['./machine-details.component.scss']
})
export class MachineDetailsComponent implements OnInit {
  machineId: number;
  containers$: Observable<any>;

  constructor(private http: HttpClient,
              private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.machineId = this.activatedRoute.snapshot.params.id;
    this.containers$ = this.http.get<any>(`${environment.apiUrl}/containers/not-sold-machines/${this.activatedRoute.snapshot.params.id}`);
  }
}
