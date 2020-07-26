import { Component, OnInit, ViewChild, SimpleChange } from '@angular/core';
import { EmployeeComponent } from './../employee/employee.component';
import { NotificationService } from '../../shared/notification.service';
import { EmployeeService } from '../../shared/employee.service';

import {MatDialogConfig,  MatDialog} from '@angular/material/dialog';
import {MatTableDataSource} from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { Type } from '@angular/compiler/src/core';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {

  constructor(private service: EmployeeService,
              private dialog: MatDialog,
              private notificationService: NotificationService) { }

  // data;
  // listData: MatTableDataSource<any>;
  result = [];
  keys;
  listData = new MatTableDataSource();
  displayedColumns: string[] = ['empID', 'firstName', 'lastName', 'age', 'city', 'actions'];
  @ViewChild(MatSort) sort: MatSort;

  ngOnInit(): void {

   console.log('Employee Get Items Called');
   this.service.getEmployees()
      .subscribe(response => {
        let result = [] ;
        let keys = Object.keys(response);
        keys.forEach(function(item){
          result.push(JSON.parse(response[item]));
        });
        console.log(result);
        this.listData.data = result;
        this.listData.sort = this.sort;
      });

  }
  // tslint:disable-next-line: use-lifecycle-interface

  onCreate(): void {
    console.log('On Create Called');
    this.service.initializeFormGroup();
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = '60%';
    this.dialog.open(EmployeeComponent, dialogConfig);
    this.onRefresh();
     }

  onEdit(row): void{
    console.log('On Edit Called');
    this.service.populateForm(row);
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = '60%';
    this.dialog.open(EmployeeComponent, dialogConfig);
    this.onRefresh();
 }

  onDelete($key): void{
     if (confirm('Are you sure to delete this record ?')){
    this.service.deleteEmployee($key);
    this.notificationService.warn('Record Deleted successfully');
     }
     this.onRefresh();
}

/* onSubmit(): void
{
  console.log('Submit Called');
  if (this.service.form.valid) {
    if (!this.service.form.get('$key').value) {
      this.service.insertEmployee(this.service.form.value);
    }
    else {
    this.service.updateEmployee(this.service.form.value);
    }
    this.service.form.reset();
    this.service.initializeFormGroup();
    this.notificationService.success('Submitted successfully');
    this.onClose();
  }
  this.onRefresh();

}

onClose() {

  console.log('Close Funtion Called');
  this.service.form.reset();
  this.service.initializeFormGroup();
  this.dialog.closeAll();
  this.onRefresh();
}

 */

onRefresh(): void{
  console.log('Data Refreshed');
  this.service.getEmployees()
     .subscribe(response => {
       let result = [] ;
       let keys = Object.keys(response);
       keys.forEach(function(item){
         result.push(JSON.parse(response[item]));
       });
       console.log(result);
       this.listData.data = result;
       this.listData.sort = this.sort;
     });

}


}
