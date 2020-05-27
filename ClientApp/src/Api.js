import $ from 'jquery';

const BaseUrl = "https://localhost:5001/api/";

export const get = (url) => $.get(BaseUrl + url);

export const post = (url, request) => $.post(BaseUrl + url, request)