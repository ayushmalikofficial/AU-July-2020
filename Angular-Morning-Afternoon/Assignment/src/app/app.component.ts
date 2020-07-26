import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Assignment';
  constructor(){

  }
ngOnInit(): void {
  console.log('App Component Created, 2 Records Added to Session Storage');
  sessionStorage.clear();
  // tslint:disable-next-line: max-line-length
  sessionStorage.setItem('1', JSON.stringify({$key: '1', firstName: 'Ayush', lastName: 'Malik', age: '24', empID: '1', city: 'New Delhi' }));
  // tslint:disable-next-line: max-line-length
  sessionStorage.setItem('2', JSON.stringify({$key: '2', firstName: 'Madhur', lastName: 'Handa', age: '24', empID: '2', city: 'New Delhi' }));
}

}
