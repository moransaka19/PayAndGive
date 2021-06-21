import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import {map, tap} from 'rxjs/operators';

@Component({
  templateUrl: './machine-details.component.html',
  styleUrls: ['./machine-details.component.scss']
})
export class MachineDetailsComponent implements OnInit {

  machine$: Observable<any>;

  constructor(private http: HttpClient,
              private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.machine$ = this.http.get<any>(`${environment.apiUrl}/machines/${this.activatedRoute.snapshot.params.id}`).pipe(
      tap(m => m.containers = m.containers.filter(x => ! x.isDeleted))
    );
  }
}
