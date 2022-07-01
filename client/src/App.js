import { Box, Container } from "@mui/material";
import PeopleTable from "./components/PeopleTable";
import "./App.css";
import { Header } from "./components/Header";

function App() {
  return (
    <Container fixed sx={{ p: 2, mt: 10 }}>
      <Box sx={{ mb: 5 }}>
        <Header />
      </Box>

      {/* <EnhancedTable /> */}
      <PeopleTable />
    </Container>
  );
}

export default App;
