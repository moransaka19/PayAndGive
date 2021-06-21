import { Component, OnInit } from '@angular/core';
import {Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {
  backups$: Observable<string[]>;

  constructor(private http: HttpClient) {
  }

  ngOnInit(): void {
    this.backups$ = this.http.get<string[]>(`${environment.apiUrl}/admin/backups`);
  }

  onBackup() {
    this.http.post(`${environment.apiUrl}/admin/backup`, null)
      .subscribe(x => {
        this.backups$ = this.http.get<string[]>(`${environment.apiUrl}/admin/backups`);
      });
  }

  onRestore(value: string) {
    this.http.post(`${environment.apiUrl}/admin/restore/${value}`, null)
      .subscribe();
  }
}
