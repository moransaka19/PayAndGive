import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Component({
  templateUrl: './machines.component.html',
  styleUrls: ['./machines.component.scss']
})
export class MachinesComponent implements OnInit {

  machines$: Observable<any>;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.machines$ = this.http.get(`${environment.apiUrl}/machines`);
  }
}
