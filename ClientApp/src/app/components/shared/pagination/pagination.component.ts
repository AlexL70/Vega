import { Component, Input, Output, EventEmitter, OnChanges } from '@angular/core';

@Component({
  selector: 'app-pagination',
  template: './pagination.component.html'
})
export class PaginationComponent implements OnChanges {
  @Input('total-items') totalItems: number;
  @Input('page-size') pageSize: number = 10;
  @Output('page-changed') pageChanged: EventEmitter<number> = new EventEmitter();
  pages: number[];
  currentPage = 1;

  constructor() { }

  ngOnChanges(): void {
    this.currentPage = 1;
    var pageCount = Math.ceil(this.totalItems / this.pageSize);
    this.pages = [];
    for (let i = 1; i <= pageCount; i++) {
      this.pages.push(i);
    }
    //console.log(this);
  }

  changePage(page: number): void {
    this.currentPage = page;
    this.pageChanged.emit(page);
  }

  previous(): void {
    if(this.currentPage == 1)
      return;
    this.currentPage--;
    this.pageChanged.emit(this.currentPage);
    // console.log('previous', this);
  }

  next(): void {
    if(this.currentPage == this.pages.length)
      return;
    this.currentPage++;
    this.pageChanged.emit(this.currentPage);
    // console.log('next', this);
  }
}
