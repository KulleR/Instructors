import { Instructor } from '../models/Instructor';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

/**
 * Provide access to manipulate with instructors via HTTP requests to Web API
 */
@Injectable()
export class InstructorsService {
    instructors: Instructor[];

    readonly apiUrl = "http://localhost:4050/api/instructors";

    constructor(private http: HttpClient) { }

    create(instructor: Instructor, success: Function = () => { },
        error: Function = () => { }) {
        return this.http.post(this.apiUrl, instructor).subscribe(
            (result: Instructor) => { // Success callback
                this.instructors.push(result);
                success(result);
            },
            (result) => { error(result) }); // Error callback
    }

    getAll(success: Function = () => { },
        error: Function = () => { }) {
        return this.http.get(this.apiUrl).subscribe(
            (result: Instructor[]) => { // Success callback
                this.instructors = result;
                success(result);
            },
            (result) => { error(result) }); // Error callback
    }

    delete(instructor: Instructor, success: Function = () => { },
        error: Function = () => { }) {
        return this.http.delete(`${this.apiUrl}/${instructor.id}`).subscribe(
            (result: Instructor) => { // Success callback
                const index = this.instructors.indexOf(instructor);
                if (index > -1) {
                    this.instructors.splice(index, 1);
                }
                success(result);
            },
            (result) => { error(result) }); // Error callback
    }

    update(instructor: Instructor, success: Function = () => { },
        error: Function = () => { }) {
        return this.http.put(`${this.apiUrl}/${instructor.id}`, instructor).subscribe(
            (result: Instructor) => { // Success callback
                let oldInstructor = this.instructors.find(i => i.id == instructor.id);
                const index = this.instructors.indexOf(oldInstructor);
                if (index > -1) {
                    this.instructors[index] = instructor;
                }
                success(result);
            },
            (result) => { error(result) }); // Error callback
    }
}