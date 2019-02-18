import { Injectable } from '@angular/core';
import Cat from '../Models/Cat';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class CatService {
  constructor(private http: HttpClient) {}

  public getAllCats() {
    // return this.http.get()
  }
}
