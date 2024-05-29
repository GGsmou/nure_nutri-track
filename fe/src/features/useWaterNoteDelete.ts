import { useMutation } from "react-query";
import { fetchAbstract } from "../utils/fetchAbstract";

export const useWaterNoteDelete = () => {
  return useMutation((data: { id: number }) => {
    return fetchAbstract("WaterNote/" + data.id, "DELETE");
  });
};
