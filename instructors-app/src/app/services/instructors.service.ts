import { Instructor } from '../models/Instructor';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class InstructorsService {
    instructors: Instructor[];

    readonly apiUrl = "http://localhost:52509/api/instructors";

    constructor(private http: HttpClient) { }

    create(instructor: Instructor, success: Function = () => { }, error: Function = () => { }, complete: Function = () => { }) {
        return this.http.post(this.apiUrl, instructor).subscribe((result: Instructor) => {
            this.instructors.push(result);
            success(result);
        }, (result) => { error(result) }, () => { complete() });
    }

    getAll(success: Function = () => { }, error: Function = () => { }, complete: Function = () => { }) {
        return this.http.get(this.apiUrl).subscribe((result: Instructor[]) => {
            this.instructors = result;
            success(result);
        }, (result) => { error(result) }, () => { complete() });
    }

    delete(instructor: Instructor, success: Function = () => { }, error: Function = () => { }, complete: Function = () => { }) {
        return this.http.delete(`${this.apiUrl}/${instructor.id}`).subscribe((result: Instructor) => {
            const index = this.instructors.indexOf(instructor);
            if (index > -1) {
                this.instructors.splice(index, 1);
            }
            success(result);
        }, (result) => { error(result) }, () => { complete() });
    }

    update(instructor: Instructor, success: Function = () => { }, error: Function = () => { }, complete: Function = () => { }) {
        return this.http.put(`${this.apiUrl}/${instructor.id}`, instructor).subscribe((result: Instructor) => {
            let oldInstructor = this.instructors.find(i => i.id == instructor.id);
            const index = this.instructors.indexOf(oldInstructor);
            if (index > -1) {
                this.instructors[index] = instructor;
            }
            success(result);
        }, (result) => { error(result) }, () => { complete() });
    }
}