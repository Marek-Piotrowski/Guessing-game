import { useState, useEffect } from "react";
import Grid from "@mui/material/Grid";
import TextField from "@mui/material/TextField";
import FormControl from "@mui/material/FormControl";
import Select from "@mui/material/Select";
import MenuItem from "@mui/material/MenuItem";
import Button from "@mui/material/Button";
import axios from "axios";
import { InputLabel } from "@mui/material";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

const defaultValues = {
  name: "",
  city: "",
  phone: "",
  country: "",
  language: "",
};

export const CreatePerson = ({ fetchUsers, handleCloseAdd }) => {
  const [addStatus, setAddStatus] = useState(0);
  const [cities, setCities] = useState([]);
  const [countries, setCountries] = useState([]);
  const [languages, setLanguages] = useState([]);

  const [formValues, setFormValues] = useState(defaultValues);

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setFormValues({
      ...formValues,
      [name]: value,
    });
  };

  const handleSubmit = async (event) => {
    event.preventDefault();
    console.log(formValues);

    const url = `http://localhost:25586/ReactPeople/addNewPerson?name=${formValues.name.toLowerCase()}&&city=${formValues.city.toLowerCase()}&&phone=${
      formValues.phone
    }&&country=${formValues.country.toLowerCase()}&&language=${formValues.language.toLowerCase()}`;

    await axios
      .get(url)
      .then((res) => setAddStatus(res.status))
      .catch((error) =>
        console.log("Something went wrong when trying to add a person.")
      );

    await fetchUsers();
    notify();
    handleCloseAdd();
  };

  const getCities = () => {
    const url = "http://localhost:25586/ReactPeople/cities";

    axios
      .get(url)
      .then((res) => setCities(res.data))
      .catch((error) => console.log("Cannot fetch cities."));
  };

  const getCountries = () => {
    const url = "http://localhost:25586/ReactPeople/countries";

    axios
      .get(url)
      .then((res) => setCountries(res.data))
      .catch((error) => console.log("Cannot fetch countries"));
  };

  const getLanguages = () => {
    const url = "http://localhost:25586/ReactPeople/languages";

    axios
      .get(url)
      .then((res) => setLanguages(res.data))
      .catch((error) => console.log("Cannot fetch languages"));
  };

  const notify = () => toast.success(`Person added `);

  useEffect(() => {
    getCities();
    getCountries();
    getLanguages();
  }, []);

  useEffect(() => {}, [addStatus]);

  return (
    <form onSubmit={handleSubmit}>
      <ToastContainer />
      <Grid
        container
        alignItems="center"
        justifyContent="center"
        direction="column"
      >
        <Grid item>
          <TextField
            id="name-input"
            name="name"
            label="Name"
            type="text"
            value={formValues.name}
            onChange={handleInputChange}
          />
        </Grid>
        <Grid item>
          <FormControl sx={{ m: 1, minWidth: 200 }} size="medium">
            <InputLabel>City</InputLabel>
            <Select
              name="city"
              value={formValues.city}
              label="City"
              onChange={handleInputChange}
            >
              {cities.map((item) => (
                <MenuItem key={item.cityId} value={item.cityName}>
                  {item.cityName}
                </MenuItem>
              ))}
            </Select>
          </FormControl>
        </Grid>
        <Grid item>
          <TextField
            id="phone-input"
            name="phone"
            label="Phone"
            type="text"
            value={formValues.phone}
            onChange={handleInputChange}
          />
        </Grid>
        <Grid item>
          <FormControl sx={{ m: 1, minWidth: 200 }} size="medium">
            <InputLabel>Country</InputLabel>
            <Select
              name="country"
              value={formValues.country}
              label="Country"
              onChange={handleInputChange}
            >
              {countries.map((item) => (
                <MenuItem key={item.countryId} value={item.countryName}>
                  {item.countryName}
                </MenuItem>
              ))}
            </Select>
          </FormControl>
        </Grid>
        <Grid item>
          <FormControl sx={{ m: 1, minWidth: 200 }} size="medium">
            <InputLabel id="language-label">Language</InputLabel>
            <Select
              labelId="language-label"
              name="language"
              value={formValues.language}
              label="Language"
              onChange={handleInputChange}
            >
              {languages.map((item) => (
                <MenuItem key={item.languageId} value={item.languageName}>
                  {item.languageName}
                </MenuItem>
              ))}
            </Select>
          </FormControl>
        </Grid>

        <Button variant="contained" color="primary" type="submit">
          Add Person
        </Button>
      </Grid>
    </form>
  );
};
