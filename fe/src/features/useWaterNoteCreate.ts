import { useMutation } from "react-query";
import { fetchAbstract } from "../utils/fetchAbstract";
import { WaterNote } from "../types/WaterNote";

export const useWaterNoteCreate = (
  filter:
    | {
        type: "edit";
        data: { id: string };
      }
    | {
        type: "create";
      },
) => {
  return useMutation((data: WaterNote) => {
    const type = filter.type === "edit" ? "PUT" : "POST";
    return fetchAbstract("WaterNote/", type, {
      ...data,
      createdAt: new Date(data.createdAt).toISOString(),
    });
  });
};
