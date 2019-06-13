import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { InstructorsService } from '../services/instructors.service';
import { MatDialogRef } from '@angular/material';

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
    private dialogRef: MatDialogRef<AddFormComponent>) { }

  onSubmit() {
    if (!this.addInstructorForm.valid) {
      return;
    }
    let instructor = Object.assign({}, this.addInstructorForm.value);
    this.isLoading = true;
    this.instructorsService.create(instructor,
      (result) => { },
      (result) => { },
      () => {
        this.onClose();
        this.isLoading = false
      });
  }

  onClose() {
    this.addInstructorForm.reset();
    this.dialogRef.close();
  }
}
