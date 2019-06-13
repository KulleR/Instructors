import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { InstructorsService } from '../services/instructors.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Instructor } from '../models/Instructor';

@Component({
  selector: 'app-edit-form',
  templateUrl: './edit-form.component.html',
  styleUrls: ['./edit-form.component.css']
})
export class EditFormComponent {
  isLoading: boolean;
  editInstructorForm = this.fb.group({
    id: [],
    firstName: [null, Validators.required],
    lastName: [null, Validators.required],
    middleName: [null, Validators.required],
  });

  constructor(private fb: FormBuilder, private instructorsService: InstructorsService,
    private dialogRef: MatDialogRef<EditFormComponent>, @Inject(MAT_DIALOG_DATA) public instructor: Instructor) {
    this.editInstructorForm.setValue(instructor);
  }

  onSubmit() {
    if (!this.editInstructorForm.valid) {
      return;
    }
    let instructor = Object.assign({}, this.editInstructorForm.value);
    this.isLoading = true;
    this.instructorsService.update(instructor,
      (result) => { },
      (result) => { },
      () => {
        this.onClose();
        this.isLoading = false
      });
  }

  onClose() {
    this.editInstructorForm.reset();
    this.dialogRef.close();
  }
}
