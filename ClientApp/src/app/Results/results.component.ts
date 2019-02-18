import { Component, OnInit } from '@angular/core';
import Cat from '../Models/Cat';
import { CatService } from '../Services/cat.service';

@Component({
  selector: 'app-results',
  templateUrl: './results.component.html',
  styleUrls: ['./results.component.scss']
})
export class ResultsComponent implements OnInit {
  public cats: Cat[];
  constructor(private catService: CatService) {}

  ngOnInit(): void {
    this.catService.getAllCats().subscribe((cats: Cat[]) => {
      this.cats = cats;
    });
  }
}
