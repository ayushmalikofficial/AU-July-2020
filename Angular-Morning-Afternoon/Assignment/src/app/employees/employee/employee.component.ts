import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../../shared/employee.service';
import { NotificationService } from '../../shared/notification.service';
import { MatDialogRef } from '@angular/material/dialog';
import { EmployeeListComponent } from '../employee-list/employee-list.component';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {


  constructor(public service: EmployeeService,
              private notificationService: NotificationService,
              public dialogRef: MatDialogRef<EmployeeComponent>,
             ) { }



  ngOnInit(): void {
  this.service.getEmployees();
  }

  onClear(): void {
  this.service.form.reset();
  this.service.initializeFormGroup();
  this.notificationService.success('Submitted successfully');
   }

  onSubmit(): void {
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
   }

onClose(): void{
  console.log('Close Called');
  this.service.form.reset();
  this.service.initializeFormGroup();
  this.dialogRef.close()
    }

}
