import axios from "axios";

const baseUrl = "https://localhost:7025/api/v2.0/book";
const getUrl = "/GetAllBooks";
const postUrl = "/";
const patchUrl = "/edit/";
const deleteUrl = "/delete/";

/* export default {
    Book(url=baseUrl + 'book/'){
        return{
            fetchAll : () => axios.get(getAll),
            fetchById :id => axios.get(url+id),
            create :newRecord => axios.post(url, newRecord),
            // hindus ma put zamiast patch
            update :(id, updateRecord) => axios.patch(url+'edit/'+id,updateRecord),
            delete :id => axios.delete(url+'delete/'+id)
        }
    }
}; */
export default {

    Book(get = baseUrl + getUrl,
        post = baseUrl + postUrl,
        patch = baseUrl + patchUrl,
        del = baseUrl + deleteUrl){
        return{
            fetchAll : () => axios.get(get),
            create :newRecord => axios.post(post, newRecord),
            // hindus ma put zamiast patch
            update :(id, updateRecord) => axios.patch(patch + id,updateRecord),
            delete :id => axios.delete(del + id)
        }
    }
};