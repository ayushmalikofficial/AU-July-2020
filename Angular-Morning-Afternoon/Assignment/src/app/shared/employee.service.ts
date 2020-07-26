import { Injectable } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {


counter: number;

constructor(){
 this.counter = 2;
}



form: FormGroup = new FormGroup({
   $key: new FormControl(null),
    firstName: new FormControl('', Validators.required),
    lastName: new FormControl('', Validators.required),
    empID: new FormControl('', [Validators.required, Validators.pattern('[1-9][1-9]*')]),
    age: new FormControl('', Validators.pattern('[1-9][1-9]*[1-9]*')),
    city: new FormControl(),

  });

initializeFormGroup(): void {
    this.form.setValue({
     $key: null,
      firstName: '',
      lastName: '',
      age: '',
      empID: '',
      city: '',
       });
  }


getEmployees(): Observable<any>{
    const items = { ...sessionStorage };
    console.log(items);
    return of(items);

  }

insertEmployee(employee): void {

     console.log('Insert Employee is Called');
     const input = { ...employee };
     console.log(input);
     this.counter++;
     input.$key = this.counter.toString();
     sessionStorage.setItem(this.counter.toString(), JSON.stringify(input));

  }

updateEmployee(employee): void {
    console.log('Update Employee is Called');
    const input = { ...employee };
    sessionStorage.setItem(input.$key, JSON.stringify(input));

  }

deleteEmployee($key: string): void {
  console.log('Delete Employee is Called');
  sessionStorage.removeItem($key);
  }

populateForm(employee): void {
    this.form.setValue(employee);
  }

}
