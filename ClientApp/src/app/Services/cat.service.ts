import { Injectable } from '@angular/core';
import Cat from '../Models/Cat';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class CatService {
  constructor(private http: HttpClient) {}

  public getAllCats() {
    return this.http.get(`/api/cats`);
  }

  public getVersusCats() {
    return this.http.get('/api/cats/versus');
  }

  public voteForcat(id: string) {
    return this.http.put(`/api/cats/vote/${id}`, null);
  }
}
