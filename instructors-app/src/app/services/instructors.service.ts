import { Instructor } from '../models/Instructor';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class InstructorsService {
    instructors: Instructor[];

    readonly apiUrl = "http://localhost:4050/api/instructors";

    constructor(private http: HttpClient) { }

    getAll(success: Function) {
        return this.http.get(this.apiUrl).subscribe((result: Instructor[]) => {
            this.instructors = result;
            success(result);
        });
    }

    create(instructor: Instructor, success: Function) {
        return this.http.post(this.apiUrl, instructor).subscribe((result: Instructor) => {
            this.instructors.push(result);
            success(result);
        });
    }

    delete(instructor: Instructor, success: Function) {
        return this.http.delete(`${this.apiUrl}/${instructor.id}`).subscribe((result: Instructor) => {
            this.instructors.slice();
            success(result);
        });
    }

    edit(instructor: Instructor, success: Function) {
        return this.http.put(`${this.apiUrl}/${instructor.id}`, instructor).subscribe((result: Instructor) => {
            const index = this.instructors.indexOf(instructor);

            this.instructors;
            success(result);
        });
    }
}