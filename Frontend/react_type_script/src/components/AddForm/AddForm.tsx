import React from 'react'
import { useForm } from 'react-hook-form'
import "./addForm.css";

type FormData = {
    title: string;
    done: boolean;
}

interface AddFormProps { }

const AddForm = (props: AddFormProps) => {
    const { register, handleSubmit, formState: { errors } } = useForm<FormData>()

    const onSubmit = handleSubmit((data: FormData) => {
        console.log(data);
    })

    return (
        <form onSubmit={onSubmit} className="form">
            <div className="form-field">
                <label htmlFor="title">Title</label>
                <input {...register("title", { required: true })} type="text" name="title" id="title" />
                {
                    errors.title && <div className="form-field-error">Enter title</div>
                }
            </div>
            <div className="form-field">
                <label htmlFor="done">Done</label>
                <input {...register("done")} type="checkbox" name="done" id="done" />
            </div>
            <button type="submit">Save</button>
        </form>
    )
}

export default AddForm
