import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { InstructorsService } from '../services/instructors.service';
import { MatDialogRef, MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-add-form',
  templateUrl: './add-form.component.html',
  styleUrls: ['./add-form.component.css'],
})
export class AddFormComponent {
  isLoading: boolean;
  addInstructorForm = this.fb.group({
    firstName: [null, Validators.required],
    lastName: [null, Validators.required],
    middleName: [null, Validators.required],
  });

  constructor(private fb: FormBuilder, private instructorsService: InstructorsService,
    private dialogRef: MatDialogRef<AddFormComponent>, private _snackBar: MatSnackBar) { }

  onSubmit() {
    if (!this.addInstructorForm.valid) {
      return;
    }
    let instructor = Object.assign({}, this.addInstructorForm.value);
    this.isLoading = true;
    this.instructorsService.create(instructor,
      (result) => {
        this._snackBar.open('Instructor created successfully.', '', { duration: 3000 });
        this.dialogRef.close();
        this.isLoading = false
      },
      (result) => {
        this._snackBar.open(`Creating a instructor failed. ${result.message}`, '', { duration: 3000 });
        this.dialogRef.close();
        this.isLoading = false
      });
  }
}
