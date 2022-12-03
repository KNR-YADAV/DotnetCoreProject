import { Component } from '@angular/core';
import { BookService } from '../serices/book.service';

@Component({
  selector: 'app-allbooks',
  templateUrl: './allbooks.component.html',
  styleUrls: ['./allbooks.component.scss']
})
export class AllbooksComponent {
 public books: any;
  constructor( private service : BookService){
  }
  private getbooks(): void {
    this.service.getallbook().subscribe(results =>{
       this.books = results;
    });
  }


}
