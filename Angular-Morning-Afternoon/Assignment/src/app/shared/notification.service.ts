import { Injectable } from '@angular/core';
import {MatSnackBar, MatSnackBarConfig} from '@angular/material/snack-bar';


@Injectable({
  providedIn: 'root'
})
export class NotificationService {

 constructor(public snackBar: MatSnackBar) { }

  config: MatSnackBarConfig = {
    duration: 3000,
    horizontalPosition: 'right',
    verticalPosition: 'top'
  };


  success(msg): void {
   // this.config['panelClass'] = ['notification', 'success'];
   this.snackBar.open(msg, '', this.config);
   console.log('Success');
  }

  warn(msg): void {
   // this.config['panelClass'] = ['notification', 'warn'];
   this.snackBar.open(msg, '', this.config);
   console.log('Warn');
  }
}
