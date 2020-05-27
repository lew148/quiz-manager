import React from 'react';
import { useField } from "react-form";

const TextField = ({ name }) => {
    const { getInputProps } = useField(name);

    return (
        <>
            <input {...getInputProps()} type="text" placeholder={name} />
        </>
    );
}

export default TextField;
