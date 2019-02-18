import { Component, OnInit } from '@angular/core';
import Cat from '../Models/Cat';
import { CatService } from '../Services/cat.service';

@Component({
  selector: 'app-vote',
  templateUrl: './vote.component.html',
  styleUrls: ['./vote.component.scss']
})
export class VoteComponent implements OnInit {
  public cats: Cat[];
  constructor(private catService: CatService) {}

  ngOnInit(): void {
    this.getVersusCats();
  }

  public getVersusCats() {
    this.catService.getVersusCats().subscribe((cats: Cat[]) => {
      this.cats = cats;
    });
  }

  public vote(cat: Cat): void {
    this.catService.voteForcat(cat.id).subscribe(res => {
      this.getVersusCats();
    });
  }
}
